using System.ComponentModel.DataAnnotations;

namespace webapi.Model;
public class Employee
{
    [Key]
    public int EmployeeID{get;set;}=default!;
       
    [Required(ErrorMessage ="Name is required")]
    [Display(Name="Employee Name")]

    [StringLength(500, ErrorMessage = "Enter minimum of 3 characters", MinimumLength = 3)]
    [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Name must contain only characters")]
    public string? Name{get;set;}
      
   
    [Required(ErrorMessage ="Age is required ")]  
    [Range(15,48, ErrorMessage ="Age must be between 15 and 48")]
    [Display(Name = "Employee Age")]
    public int? Age{get;set;}  //? to avoid null or empty

    [Required(ErrorMessage ="Email is required")]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
    [MaxLength(50)] 
    [RegularExpression(@"^[a-z][a-z0-9._%+-]*@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Email is not Vaild")]//starts with character ,remaining with number or dot 
    public string? EmailId{get;set;}

    [Required(ErrorMessage =" Permanent Address is required")] 
    [Display(Name = "Permanent Address")]
    [RegularExpression(@"^[a-zA-Z0-9\s\.,'-]*$", ErrorMessage = "Invalid Address Format")] //*allow uppercase,lowercae (, . ' -)  allow Zero or more occurences of mentioned pattern
    public string? Address{get;set;}
   
    
    [Required(ErrorMessage ="Password is required")]  
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
     [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{3,15}$",ErrorMessage = "Use Uppercase, Lowercase, Numbers, Symbols ")]  
    [StringLength(100, ErrorMessage = "Minimum of 3 to 15 characters", MinimumLength = 3)]
     public string? password{get;set;}
   
    [Required(ErrorMessage = "Contact is required")]  
    [DataType(DataType.PhoneNumber)] 
    [Display(Name = "Phone Number")]
       [RegularExpression(@"^+[6-9][0-9]{9,11}$", ErrorMessage = "Please Enter 10 digit Valid PhoneNumber")] 
    public string? contact{get;set;}
}
 public  partial class Logindetail
{
    [Required(ErrorMessage =" Name is required")]  
    [StringLength(500, ErrorMessage = "Enter minimum of 3 characters", MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Name must contain only characters")]
    public string? Name{get;set;}
    
    [Required(ErrorMessage ="Password is required")]  
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{3,15}$",ErrorMessage = "Use Uppercase, Lowercase, Numbers, Symbols ")]  
    [StringLength(100, ErrorMessage = "Minimum of 3 to 15 characters", MinimumLength = 3)]
     public string? password{get;set;}
   
}
public class Response
{
    public string? Status{get;set;}
    public string? Message{get;set;}
}
public class RegisterModel
{
    public string Username{get;set;}
    public string Email{get;set;}
    public string Password{get;set;}
}
public class LoginModel
{
    public string Username{get;set;}
    public string Password{get;set;}
}