using System;

namespace RegistroEstudiantes.Services
{
    public class AlertaService
    {
        public string? Mensaje { get; private set; }
        public string Tipo { get; private set; } = "success";

        public event Action? OnChange;

        public void Mostrar(string mensaje, string tipo)
        {
            Mensaje = mensaje;
            Tipo = tipo;
            NotifyStateChanged();
        }

        public void Limpiar()
        {
            Mensaje = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
