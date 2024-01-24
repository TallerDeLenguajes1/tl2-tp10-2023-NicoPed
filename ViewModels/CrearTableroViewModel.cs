using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_NicoPed;
namespace tl2_tp10_2023_NicoPed.ViewModels;

public class CrearTableroViewModel
{
    private int id_usuario_propietario;
    private string? nombre;
    private string? descripcion;
    private string? nombreUsuarioPropietario;
    private int idUsuarioPropietario;
    public CrearTableroViewModel()
    {
    }
    public CrearTableroViewModel(Usuario usuario)
    {
        nombreUsuarioPropietario = usuario.Nombre_de_usuario;
        idUsuarioPropietario = usuario.Id_usuario;
    }
    public int Id_usuario_propietario { get => id_usuario_propietario; set => id_usuario_propietario = value; }
    [Required(ErrorMessage = "Este campo es requeri6do")]
    [Display(Name = "Nombre del tablero")]
    public string? Nombre { get => nombre; set => nombre = value; }
    [Display(Name = "Descripción del tablero")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? NombreUsuarioPropietario { get => nombreUsuarioPropietario; }
    public int IdUsuarioPropietario { get => idUsuarioPropietario; }

}