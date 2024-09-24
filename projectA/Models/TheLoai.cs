using System.ComponentModel.DataAnnotations;

namespace projectA.Models
{
	public class TheLoai
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Không được để trống tên thể loại")]
		[StringLength(10, ErrorMessage = "Tên thể loại không được quá 10 ký tự")]
		[Display(Name = "Tên Thể Loại")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Không được để trống ngày tạo")]
		[Display(Name = "Ngày Tạo")]
		public DateTime? DateCreated { get; set; } = DateTime.Now;
	}

}
