﻿namespace MSF.Powershell.Meterpreter
{
    public static class User
    {
        private const string SystemSID = "S-1-5-18";

        public static string GetUid()
        {
            System.Diagnostics.Debug.Write("[PSH BINDING] Invoking binding call GetUid");

            Tlv tlv = new Tlv();

            var result = Core.InvokeMeterpreterBinding(true, tlv.ToRequest("stdapi_sys_config_getuid"));

            if (result != null)
            {
                var responseTlv = Tlv.FromResponse(result);
                if (responseTlv[TlvType.Result].Count > 0 &&
                    (int)responseTlv[TlvType.Result][0] == 0)
                {
                    return (string)responseTlv[TlvType.UserName][0];
                }
            }

            return null;
        }
    }
}
