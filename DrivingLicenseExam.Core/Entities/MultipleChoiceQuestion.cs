namespace DrivingLicenseExam.Core.Entities;

public class MultipleChoiceQuestion : Question
{
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }
}