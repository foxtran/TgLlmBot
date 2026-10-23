using System;
using System.Text;

namespace TgLlmBot.Commands.Model;

public static class ModelInfoFormatter
{
    public static string Build(ModelCommandHandlerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        var builder = new StringBuilder();
        builder.Append("Провайдер: `").Append(GetBaseUrl(options.Endpoint)).AppendLine("`");
        builder.Append("Модель: `").Append(options.Model).AppendLine("`");
        builder.AppendLine();
        builder.AppendLine("Возможности модели:");
        builder.Append("Картинки: `").Append(options.Image).AppendLine("`");
        builder.Append("Видео: `").Append(options.Video).AppendLine("`");
        builder.Append("Аудио: `").Append(options.Audio).AppendLine("`");
        return builder.ToString();
    }

    private static string GetBaseUrl(Uri uri)
    {
        ArgumentNullException.ThrowIfNull(uri);
        if (!uri.IsAbsoluteUri)
        {
            throw new ArgumentException("URI должен быть абсолютным", nameof(uri));
        }

        return uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
    }
}
