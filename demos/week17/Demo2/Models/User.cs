namespace Demo2.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class User {

	[Key]
	public int UserId { get; set; }

	public string UserName { get; set; }

	
	public ICollection<UserPost> Posts { get; set; }


	public User() {
		UserId = -1;
		UserName = string.Empty;
		Posts = new List<UserPost>();
	}
}
