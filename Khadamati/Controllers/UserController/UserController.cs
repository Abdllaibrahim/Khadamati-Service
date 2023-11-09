using Khadamati.BLL;
using Khadamati.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Khadamati
{
    [ApiController]
    public class UserController:Controller
    {
        public UserManager<SiteUser> UserManager;
        private readonly IConfiguration _configuration;
        public ISiteuserManger SiteuserManger;

        public UserController(IConfiguration configuration, UserManager<SiteUser> userManager, ISiteuserManger siteuser)
        {
            _configuration = configuration; 
            UserManager = userManager;
            SiteuserManger = siteuser;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<UserReadDto>> GetAll()
        {
            return SiteuserManger.GetAll();
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserReadDto>> GetAllUsers()
        {
            return SiteuserManger.GetAllUsers();
        }
        [HttpGet]
        [Route("GetAllAdmins")]
        public ActionResult<List<UserReadDto>> GetAllAdmins()
        {
            return SiteuserManger.GetAllAdmins();
        }
        [HttpGet]
        [Route("GetbyID")]
        public ActionResult<UserReadDto> GetbyID(string ID)
        {
            return SiteuserManger.GetUser(ID);
        }
        [HttpGet]
        [Authorize(Policy = "UserPolicy")]
        [Route("GetDetailsbyID")]
        public async Task<ActionResult<UserDetailsDTO>> GetDetailsbyID()
        {
            var id = await UserManager.GetUserAsync(User);
            if(id==null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return SiteuserManger.GetUserDetails(id.Id);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(UserUpdateDto userUpdate)
        {
            SiteUser? user = await UserManager.GetUserAsync(User);
            //string id = UserManager.GetUserId(User);
            SiteuserManger.UpateUserData(user.Id, userUpdate);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete]
        [Route("Remove")]
        public ActionResult Remove(string id)
        {
            //string id = UserManager.GetUserId(User);
            SiteuserManger.RemoveUser(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        [Route("login")]
        //=> /api/users/static-login
        public async Task<ActionResult<string>> Login(UserLoginDTO credentials)
        {
            #region Username and Password verification

            SiteUser? user = await UserManager.FindByNameAsync(credentials.username);
            if (user is null)
            {
                return StatusCode(0);
            }

            bool isPasswordCorrect = await UserManager.CheckPasswordAsync(user, credentials.password);
            if (!isPasswordCorrect)
            {
                return StatusCode(1);
            }

            #endregion

            #region Generate Token

            var claimsList = await UserManager.GetClaimsAsync(user);
            string secretKey = _configuration.GetValue<string>("SecretKey")!;
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claimsList,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMonths(3));
            var tokenHandler = new JwtSecurityTokenHandler();
            string t = tokenHandler.WriteToken(token);
            return Ok( new
            {
                usertoken = t,
                userclaims = claimsList.Select(i=>i.Value),
            }) ;

            #endregion
        }
        [HttpPost]
        [Route("User/Register")]
        public async Task<ActionResult> Register(UserAddDTO registerDto)
        {
            var siteUser = new SiteUser
            {
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone,
                Email = registerDto.Email,
                Location = registerDto.Location,
            };

            var result = await UserManager.CreateAsync(siteUser, registerDto.Password);
           
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claimsLsit = new List<Claim>()
            { 
                new Claim(ClaimTypes.NameIdentifier,siteUser.Id),
                new Claim(ClaimTypes.Role,"User")
            };

            await UserManager.AddClaimsAsync(siteUser, claimsLsit);

            string secretKey = _configuration.GetValue<string>("SecretKey")!;
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claimsLsit,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMonths(3));
            var tokenHandler = new JwtSecurityTokenHandler();
            string t = tokenHandler.WriteToken(token);
            return Ok(new
            {
                usertoken = t
            });
        }
        [HttpPost]
        [Route("Admin/Register")]
        public async Task<ActionResult> AdminRegister(UserAddDTO registerDto)
        {
            var user = new SiteUser
            {
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone,
                Email = registerDto.Email,
                Location = registerDto.Location,
            };
            var result = await UserManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            var claimsLsit = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Admin")
            };
            await UserManager.AddClaimsAsync(user, claimsLsit);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("AddBookmark")]
        public async Task<ActionResult> AddBookMark(int serviceID)
        {
            var user = await UserManager.GetUserAsync(User);
            SiteuserManger.AddBookmark(user.Id, serviceID);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete]
        [Route("DeleteBookmark")]
        public async Task<ActionResult> RemoveBookMark(int serviceID)
        {
            var user = await UserManager.GetUserAsync(User);
            SiteuserManger.RemoveBookmark(user.Id, serviceID);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
