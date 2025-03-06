using FIT_Api_Examples.Data;
using System;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Dodaj;

public class DodajNoviUpisRequest
{
    public int StudentId { get; set; }
    public int AkademskaGodinaId { get; set; }
    public int Godina { get; set; }
    public bool Obnova { get; set; }
    public DateTime DatumUpisa { get; set; }
    public float CijenaSkolarine { get; set; }
    public int EvidentiraoId { get; set; }
}