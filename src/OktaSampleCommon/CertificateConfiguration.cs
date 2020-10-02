﻿using System;

namespace OktaSampleCommon
{
    public class CertificateConfiguration
    {
        public bool UseLocalCertStore { get; set; }
        public string CertificateThumbprint { get; set; }
        public string CertificateNameKeyVault { get; set; }
        public string KeyVaultEndpoint { get; set; }
        public string DevelopmentCertificatePfx { get; set; }
        public string DevelopmentCertificatePassword { get; set; }
    }
}
