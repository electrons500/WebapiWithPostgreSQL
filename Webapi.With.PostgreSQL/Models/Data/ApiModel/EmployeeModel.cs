using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webapi.With.PostgreSQL.Models.Data.ApiModel
{
    public class EmployeeModel
    {
        [Key]
        [DisplayName("Id")]
        public int Employeeid { get; set; }
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
