using APIWeb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

public static class Funciones
{
    public static IActionResult GetErrorResponse(Exception exception, int statusCode = StatusCodes.Status500InternalServerError, string customMessage = "Desconocido")
    {
        // Aquí puedes agregar lógica para detectar y transformar excepciones en respuestas de texto
        string errorMessage = "Error desconocido.";

        if (exception is InvalidOperationException)
        {
            errorMessage = "Operación no válida: " + exception.Message;
        }
        else if (exception is ArgumentException)
        {
            errorMessage = "Argumento no válido: " + exception.Message;
        }

        if (!string.IsNullOrEmpty(customMessage))
        {
            errorMessage = customMessage; // Utiliza el mensaje personalizado si se proporciona
        }

        // Detecta los errores de código de estado y muestra mensajes personalizados
        switch (statusCode)
        {
            case StatusCodes.Status400BadRequest:
                errorMessage = customMessage;
                break;
            case StatusCodes.Status401Unauthorized:
                errorMessage = customMessage;
                break;
            case StatusCodes.Status403Forbidden:
                errorMessage = customMessage;
                break;
            default:
                errorMessage = "Error desconocido: " + exception.Message;
                break;
        }

        // Devuelve una respuesta de texto con el mensaje de error y el código de estado adecuados
        return new ObjectResult(errorMessage)
        {
            StatusCode = statusCode,
            ContentTypes = { "text/plain" }
        };
    }




}
