using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.UserModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocnetCorePractice.Services
{
    public class RandomStringGenerator
    {
        private static Random random = new Random();
        private const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characters.Length);
                sb.Append(characters[index]);
            }

            return sb.ToString();
        }
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string Key = "suifbweudfwqudgweufgewufgwefcgweiudgweidgwed";
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRefreshTokenRepository _refreshToken;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper, IRefreshTokenRepository refreshToken)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _refreshToken = refreshToken;
        }

        public ResponseLoginModel Authenticator(RequestLoginModel model)
        {
            //var account =             //viết repository get UserEntity
            //if (account == null)
            //{
            // kiểm tra nếu user == null thì thorw ex
            //}
            var account = _userRepository.GetUser(model);
            if(account == null)
            {
                throw new Exception("No account found!!");
            }

            var token = CreateJwtToken(account);
            var refreshToken = CreateRefreshToken(account);
            var result = new ResponseLoginModel
            {
                UserName = account.UserName,
                FullName = account.FullName,
                UserEmail = account.UserEmail,
                Token = token,
                RefreshToken = refreshToken.Token
            };
            return result;
        }

        private RefreshToken CreateRefreshToken(UserEntity account)
        {
            var randomByte = new byte[64];
            var token = RandomStringGenerator.GenerateRandomString(5); // Viết hàm tạo chuỗi random string
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid().ToString("N"),
                UserId = account.Id,
                Expires = DateTime.Now.AddDays(1),
                IsActive = true,
                Token = token
            };
            // viết code insert refreshToken vào DB
            _refreshToken.Add(refreshToken);
            
            return refreshToken;
        }

        private string CreateJwtToken(UserEntity account)
        {
            var tokenHanler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Key);
            var securityKey = new SymmetricSecurityKey(key);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            string roleValue = "";
            if (account.Role == BotTournamentManagement.Data.Enum.Role.Organizer)
            {
                roleValue = "admin";
            }
            if (account.Role == BotTournamentManagement.Data.Enum.Role.HeadReferee)
            {
                roleValue = "head-referee";
            }
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, account.FullName),
                    new Claim(ClaimTypes.Email, account.UserEmail),
                    new Claim(ClaimTypes.Role, roleValue),
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = credential
            };
            var token = tokenHanler.CreateToken(tokenDescription);
            return tokenHanler.WriteToken(token);
        }

    }
}
