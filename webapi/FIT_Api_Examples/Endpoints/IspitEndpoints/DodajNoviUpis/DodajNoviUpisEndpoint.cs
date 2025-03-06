using System;
using System.Threading;
using System.Threading.Tasks;
using FIT_Api_Example.Helper;
using FIT_Api_Examples.Data;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Dodaj;

[Route("ispit")]
public class DodajNoviUpisEndpoint : MyBaseEndpoint<DodajNoviUpisRequest, DodajNoviUpisResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public DodajNoviUpisEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("dodaj_novi_upis")]
    public override async Task<DodajNoviUpisResponse> Obradi([FromBody] DodajNoviUpisRequest request, CancellationToken cancellationToken)
    {
        var noviUpis = new StudentMaticnaKnjiga
        {
            StudentId = request.StudentId,
            AkademskaGodinaId = request.AkademskaGodinaId,
            Godina = request.Godina,
            Obnova = request.Obnova,
            DatumUpisa = request.DatumUpisa,
            CijenaSkolarine = request.CijenaSkolarine,  
            EvidentiraoId = request.EvidentiraoId
        };

        _applicationDbContext.StudentMaticnaKnjiga.Add(noviUpis);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);//izvrašva se "insert into Ispit value ...."

        return new DodajNoviUpisResponse
        {
            Upisan = true,
            Greska = null
        };
    }


}