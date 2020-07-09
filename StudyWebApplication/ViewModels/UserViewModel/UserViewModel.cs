using System.ComponentModel.DataAnnotations;

namespace StudyWebApplication.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "사용자 ID을 입력하세요.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")]
        public string UserPassword { get; set; }
    }
}
