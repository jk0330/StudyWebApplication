using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWebApplication.ViewModel
{
    public class DtoUser
    {
        [Required(ErrorMessage = "사용자 ID을 입력하세요.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")]
        public string UserPassword { get; set; }
    }
}
