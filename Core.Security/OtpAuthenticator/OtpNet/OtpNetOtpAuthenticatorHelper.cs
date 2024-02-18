﻿using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.OtpAuthenticator.OtpNet;

public class OtpNetOtpAuthenticatorHelper: IOtpAuthenticatorHelper
{
    public Task<string> ConvertSecretKeyToString(byte[] secretKey)
    {
        string base32String = Base32Encoding.ToString(secretKey);
        return Task.FromResult(base32String);
    }

    public Task<byte[]> GenerateSecretKey()
    {
        byte[] secretKey = KeyGeneration.GenerateRandomKey(20);

        string base32String = Base32Encoding.ToString(secretKey);
        byte[] base32Bytes = Base32Encoding.ToBytes(base32String);

        return Task.FromResult(base32Bytes);
    }

    public Task<bool> VerifyCode(byte[] secretKey, string code)
    {
        Totp totp = new(secretKey);

        string totpCode = totp.ComputeTotp(DateTime.Now);

        return Task.FromResult(totpCode == code);
    }
}
