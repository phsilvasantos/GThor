using GThorFrameworkBiblioteca.Ferramentas.HelpersCriptografia;

namespace GThorFrameworkDominio.Base
{
    public abstract class EntidadeDominio
    {
        private string Hash { get; } = Md5Helper.CriaUnica();
        protected abstract int IdUnico { get; }

        public static bool operator ==(EntidadeDominio left, EntidadeDominio right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntidadeDominio left, EntidadeDominio right)
        {
            return !Equals(left, right);
        }

        private bool Equals(EntidadeDominio other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((EntidadeDominio)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return IdUnico > 0 ? IdUnico * 397 : Hash.GetHashCode();
            }
        }
    }
}