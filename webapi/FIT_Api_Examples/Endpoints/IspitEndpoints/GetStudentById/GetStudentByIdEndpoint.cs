using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FIT_Api_Example.Helper;
using FIT_Api_Examples.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Dodaj;

[Route("ispit")]
public class GetStudentByIdEndpoint : MyBaseEndpoint<GetStudentByIdRequest,  Student>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GetStudentByIdEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet("get_student_by_id")]
    public override async Task<Student> Obradi([FromQuery] GetStudentByIdRequest request, CancellationToken cancellationToken)
    {
        var student = await _applicationDbContext.Student
                                     .Include(x => x.opstina_rodjenja.drzava)
                                     .Where(x => x.id == request.Id)
                                     .FirstOrDefaultAsync();

        if(student == null) 
            return null;

        return student;
    }


}