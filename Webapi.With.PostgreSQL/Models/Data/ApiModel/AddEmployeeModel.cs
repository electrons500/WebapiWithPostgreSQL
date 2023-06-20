using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Webapi.With.PostgreSQL.Models.Data.ApiModel
{
    public class AddEmployeeModel
    {
        [Required]
        [DisplayName("Name")]
        [DataType(DataType.Text)]
        public string Employeename { get; set; } = null!;
        [Required]
        [DisplayName("Age")]
        [DataType(DataType.Text)]
        public int Age { get; set; }
        [Required]
        [DisplayName("City")]
        [DataType(DataType.Text)]
        public string City { get; set; } = null!;
    }
}
