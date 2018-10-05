using System.Collections.Generic;

namespace Cmp02.Entities
{
    public class Cliente
    {
        public Tb_Persona_Natural Persona { get; set; }
        public Tb_Domicilio Domicilio { get; set; }
        public List<Tb_Medio_Contacto> Medios { get; set; }
        public Tb_Colegiado_Estudio Estudio { get; set; }
    }
}
