using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_TokenLab.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        
        
        
        [Column(TypeName="nvarchar(250)")]
        [Required (ErrorMessage ="Este campo é de preenchimento")]
        [DisplayName("Evento")]
        public string FullName { get; set; }
       
        
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Data Início")]
        public string EmpCode  { get; set; }
       
        
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Data Fim")]
        public string Position { get; set; }
       
        
        
        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Descrição do evento")]
        public string OfficeLocation { get; set; }

    }
}
