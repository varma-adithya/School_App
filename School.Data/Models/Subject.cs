﻿namespace School.Data.Models
{
	public class Subject : IId
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }
	}
}
