using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FIT_Api_Example.Helper;
using FIT_Api_Examples.Data;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Obrisi;

[Route("ispit")]
public class SoftDeleteStudentEndpoint : MyBaseEndpoint<SoftDeleteStudentRequest,  Student>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SoftDeleteStudentEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("soft_delete_student")]
    public override async Task<Student> Obradi([FromBody] SoftDeleteStudentRequest request, CancellationToken cancellationToken)
    {

        var student = await _applicationDbContext.Student.FindAsync(request.StudentID);

        if (student == null)
        {
            throw new Exception("nije pronadjen student sa id = " + request.StudentID);
        }

        student.Obrisan = true;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return student;
    }
}