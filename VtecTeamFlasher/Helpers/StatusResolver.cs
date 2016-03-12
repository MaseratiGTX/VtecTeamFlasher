using System.Collections.Generic;
using ClientAndServerCommons.Statuses;

namespace VtecTeamFlasher.Helpers
{
    public static class StatusResolver
    {
        private static readonly Dictionary<int, string> reflashStatuses = new Dictionary<int, string>();
        private static readonly Dictionary<int, string> requestStatuses = new Dictionary<int, string>();

        static StatusResolver()
        {
            reflashStatuses.Add((int)ReflashStatuses.BinaryDownloaded, "Прошивка загружена");
            reflashStatuses.Add((int)ReflashStatuses.BinaryRequestReceived, "Запрос принят");
            reflashStatuses.Add((int)ReflashStatuses.BinaryUploadedToECU, "Не оплачено");
            reflashStatuses.Add((int)ReflashStatuses.PaymentReceived, "Платеж принят");
            reflashStatuses.Add((int)ReflashStatuses.PaymentSend, "Платеж отправлен");

            requestStatuses.Add((int)RequestStatuses.New, "Новый");
            requestStatuses.Add((int)RequestStatuses.Closed, "Закрыт");
            requestStatuses.Add((int)RequestStatuses.DataSended, "Данные отправлены");
            requestStatuses.Add((int)RequestStatuses.InProgress, "Обрабатывается");
            requestStatuses.Add((int)RequestStatuses.NeedCheck, "Требует проверки");
            requestStatuses.Add((int)RequestStatuses.NeedData, "Необходимы данные");
            requestStatuses.Add((int)RequestStatuses.Postponed, "Отложен");
            
        }

        public static string ResolveReflashStatus(int key)
        {
            return reflashStatuses[key];
        }

        public static string ResolveRequestStatus(int key)
        {
            return requestStatuses[key];
        }
    }
}
