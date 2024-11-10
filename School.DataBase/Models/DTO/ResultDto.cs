﻿namespace School.DataBase.Models.DTO;

public class ResultDto
{
    public bool IsSuccess { get; set; }
    public string? Token { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}