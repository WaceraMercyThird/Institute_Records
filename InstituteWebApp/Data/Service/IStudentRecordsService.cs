using InstituteWebApp.Data.Models;
using InstituteWebApp.Models;

namespace InstituteWebApp.Data.Service;

public interface IStudentRecordsService
{
   public Task<List<StudentsModels>> GetStudentRecords();
   
   
}