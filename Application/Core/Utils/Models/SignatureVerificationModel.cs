﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Utils.Models
{
    public class SignatureVerificationModel
    {
        [Required]
        public string DecryptionPrivateKey { get; set; }

        [Required]
        public string SignaturePublicKey { get; set; }

        [Required]
        public string EncryptedKey { get; set; }

        [Required]
        public string EncryptedIv { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string Signature { get; set; }
    }
}
