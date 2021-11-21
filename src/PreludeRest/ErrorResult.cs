using System;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PreludeRest
{
    /// <summary>A machine-readable way to model error details in an HTTP response based on
    /// https://datatracker.ietf.org/doc/html/rfc7807</summary>.
    public class ErrorResult : IEquatable<ErrorResult>
    {
        static class PropertyName
        {
            public const string Type = "type";
            public const string Title = "title";
            public const string Status = "status";
            public const string Detail = "detail";
            public const string Instance = "instance";
        }

        public ErrorResult() => Type = "about:blank";

        [JsonPropertyName(PropertyName.Type)]
        [JsonProperty(PropertyName.Type)]
        public string Type { get; set; }

        [JsonPropertyName(PropertyName.Title)]
        [JsonProperty(PropertyName.Title)]
        public string Title { get; set; }

        [JsonPropertyName(PropertyName.Status)]
        [JsonProperty(PropertyName.Status)]
        public int? Status { get; set; }

        [JsonPropertyName(PropertyName.Detail)]
        [JsonProperty(PropertyName.Detail)]
        public string Detail { get; set; }

        [JsonProperty(PropertyName.Instance)]
        [JsonPropertyName(PropertyName.Instance)]
        public string Instance { get; set; }

        /// <summary>Returns a string representation of an <c>ErrorResult</c> instance.</summary>
        public override string ToString() =>
            new StringBuilder()
                .AppendLine("ErrorResult (")
                .Append("  Type: ").Append(Type).Append(Environment.NewLine)
                .Append("  Title: ").Append(Title).Append(Environment.NewLine)
                .Append("  Status: ").Append(Status).Append(Environment.NewLine)
                .Append("  Detail: ").Append(Detail).Append(Environment.NewLine)
                .Append("  Instance: ").Append(Instance).Append(Environment.NewLine)
                .Append(")")
            .ToString();

        /// <summary>Returns true if objects are equal.</summary>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ErrorResult)obj);
        }

        /// <summary>Returns a value indicating whether this instance is equal to a specified
        /// <c>ErrorResult</c> instance.</summary>
        public bool Equals(ErrorResult other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    Status == other.Status ||
                    Status != null &&
                    Status.Equals(other.Status)
                ) && 
                (
                    Detail == other.Detail ||
                    Detail != null &&
                    Detail.Equals(other.Detail)
                ) && 
                (
                    Instance == other.Instance ||
                    Instance != null &&
                    Instance.Equals(other.Instance)
                );
        }

        /// <summary>Returns the hash code for this instance.</summary>
        public override int GetHashCode()
        {
            unchecked {
                var hashCode = 2;
                if (Type != null)
                    hashCode = hashCode * 3 + Type.GetHashCode();
                if (Title != null)
                    hashCode = hashCode * 3 + Title.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 3 + Status.GetHashCode();
                if (Detail != null)
                    hashCode = hashCode * 3 + Detail.GetHashCode();
                if (Instance != null)
                    hashCode = hashCode * 3 + Instance.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ErrorResult left, ErrorResult right) => Equals(left, right);

        public static bool operator !=(ErrorResult left, ErrorResult right) => !Equals(left, right);
    }
}
