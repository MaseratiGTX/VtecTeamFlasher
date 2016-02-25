using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientAndServerCommons.Statuses
{
    public enum ReflashStatuses
    {
        BinaryRequestReceived = 1,
        BinaryDownloaded = 2,
        BinaryUploadedToECU =3,
        PaymentSend=4,
        PaymentReceived=5
    }
}
