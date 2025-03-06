using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FIT_Api_Example.Helper;
using FIT_Api_Examples.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Dodaj;

[Route("ispit")]
public class GetMaticnaKnjigaByStudentIdEndpoint : MyBaseEndpoint<GetMaticnaKnjigaByStudentIdRequest,  List<StudentMaticnaKnjiga>>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GetMaticnaKnjigaByStudentIdEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet("get_maticna_knjiga_by_student_id")]
    public override async Task<List<StudentMaticnaKnjiga>> Obradi([FromQuery] GetMaticnaKnjigaByStudentIdRequest request, CancellationToken cancellationToken)
    {
        var studentMaticnaKnjiga = await _applicationDbContext.StudentMaticnaKnjiga
                                     .Include(x => x.AkademskaGodina)
                                     .Include(x=> x.Evidentirao)
                                     .Where(x => x.StudentId == request.StudentId)
                                     .ToListAsync();

        return studentMaticnaKnjiga;
    }


}