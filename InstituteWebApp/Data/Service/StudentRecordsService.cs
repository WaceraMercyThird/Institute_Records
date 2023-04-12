using InstituteWebApp.Data.Models;
using InstituteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstituteWebApp.Data.Service;

public class StudentRecordsService : IStudentRecordsService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StudentRecordsService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<StudentsModels>> GetStudentRecords()
    {

        return await _applicationDbContext.StudentsRecord.ToListAsync();


    }
}