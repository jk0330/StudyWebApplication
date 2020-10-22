using System.ComponentModel.DataAnnotations;

namespace StudyWebApplication.Models
{
    public class Users
    {
        [Required(ErrorMessage = "사용자 ID을 입력하세요.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "사용자 이름을 입력하세요.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")]
        public string UserPassword { get; set; }
    }
}
