using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace APS.net_Entity_.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName ="nvarchar")]
        [DisplayName("Tiêu đề")]
        public string? Title { get; set; }
        [DisplayName("Ngày tạo")]

        [DataType(DataType.Date)]
        public DateTime Created {  get; set; }
        [DisplayName("Nội dung")]
        [Column(TypeName ="ntext")]
        public string? Content { get;set; }
    }
    /*
     * CREATE, READ,UPDATE,DELETE(CRUD)
     * 
     * dotnet aspnet-codegenerator razorpage -m APS.net_Entity_.Models.Article -dc APS.net_Entity_.Models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries
     * 
     */
    /*
     * Identity:
     *  - Athentication : Xác định danh tính -> Login,Logout
     *  - Authorization: Xác thực quyền truy cập
     *  - Quản lí user: Sign up, User, Role....
     *  
     *  /Identity/Account/Login
     */
}
