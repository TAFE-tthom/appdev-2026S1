namespace Demo2.Models;

using System.ComponentModel.DataAnnotations;

public class UserPost {
	[Key]
	public int PostID { get; set; }
	public string PostContent { get; set; }
	public int UserID { get; set; }

	public User User { get; set; }

	public UserPost() {
		PostID = -1;
		PostContent = string.Empty;

		UserID = -1;
		User = null;
	}
	
}
