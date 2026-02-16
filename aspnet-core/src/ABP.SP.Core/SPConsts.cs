using ABP.SP.Debugging;

namespace ABP.SP;

public class SPConsts
{
    public const string LocalizationSourceName = "SP";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fdea09447aca4680b461775af16f16df";
}
