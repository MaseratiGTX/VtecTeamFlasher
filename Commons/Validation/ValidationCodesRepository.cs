using System;

namespace Commons.Validation
{
    public class ValidationCodesRepository
    {
        public const int AnotherReasonValidationFailed = 000;

        public const int OperationRequestIsNull = 001;
        public const int AcceptOperationRequestIsNull = 002;
        public const int CancelOperationRequestIsNull = 003;


        public const int KKMClientSystemGUIDIsNull = 020;
        public const int NotRegistered_KKMClientSystemGUID = 021;
        public const int CurrencyCodeIsNull = 022;
        public const int NotRegistered_CurrencyCode = 023;
        public const int ClientContextIsNull = 024;

        public const int ClientSystemGUIDIsNull = 026;
        public const int NotRegistered_ClientSystemGUID = 027;
        public const int FiscalisationSystemGUIDIsNull = 028;
        public const int NotRegistered_FiscalisationSystemGUID = 029;
        public const int AmmountIsNegative = 030;
        public const int CashierIdIsNull = 031;
        public const int NotRegistered_CashierId = 032;
        public const int CashDeskIdIsNull = 033;
        public const int NotRegistered_CashBoxId = 034;
        public const int NotRegistered_RKOId = 035;
        public const int IllegalFiscalisationSystemGUID = 036;
        public const int CashBoxDoesNotBelongsToKKM = 037;
        public const int KKMNotBelongsToRKO = 038;
        public const int NotExisted_WorkSessionNumber = 039;

        public const int KKMIsNotInFiscalMode = 040;
        public const int KKMIsNotEnabled = 041;

        public const int RegistrationCardIsNull = 060;
        public const int RegistrationCardInformationIsNotFilled = 061;
        public const int KKMIsDeregistrated = 062;
        public const int RegistrationCardIsNotCurrent = 063;
        public const int KKMTypeIsNotAllowed = 064;
        public const int RegistrationCardDoesNotExist = 065;
        public const int KKMTypeIsEmpty = 066;
        public const int KKMTypeIsWrong = 067;


        public const int KKMIsOnline_DocumentNumberFilled = 080;
        public const int KKMIsOnline_OperationDateIsBeforeTheBeginningOfTheWorkSession = 081;
        public const int KKMIsOnline_OperationDateIsEarlierThenTheLastOperation = 082;
        public const int KKMIsOnline_NumberInWorkSessionFilled = 083;
        public const int NumberInWorkSessionIsNull = 084;

        public const int KKMIsOffline_DocumentNumberIsNotFilled = 100;
        public const int KKMIsOffline_NumberInWorkSessionIsNotFilled = 101;


        public const int WorkSessionTimeHasBeenExceeded = 120;

        public const int LoginNotFound = 130;
        public const int WrongPassword = 131;
        public const int UserBanned = 132;
        public const int NoPermissionRule = 133;
        public const int PasswordTooSmall = 134;
        public const int WrongLogin = 135;
        public const int CashierHasAnotherTaxPayer = 136;
        public const int CashierHasNoKeyContainer = 137;


        public const int No_Operations_Registered = 139;
        public const int Operation_NegativeAmount = 140;
        public const int Operation_ClientSystemGUIDIsNull = 141;
        public const int Operation_OperationDateIsInClosedWorkSession = 142;
        public const int SuchOperationIsAlreadyRegistered = 143;
        public const int SuchDocumentNumberIsAlreadyRegistered = 144;
        public const int Operation_OperationDateIsEarlierThanRegistrationCardRegistrationDate = 145;
        public const int Operation_WrongType = 146;
        public const int ReversingOperationDateIsEarlierThenReversedOperationDate = 147;
        public const int ClientSystemGUIDIsRegistered = 148;
        public const int OperationDateTimeExceeded = 149;

        public const int SessionTimeSpanExceeded = 150;

        public const int ReversingOperationNotFound = 151;

        public const int ExchangeOperationIncomeCurrencyOutgoingCurrencyIsEqual = 152;

        public const int FiscalItem_WrongType = 160;
        public const int FiscalItem_IsReversed = 162;
        public const int FiscalItem_IsNotAccepted = 163;
        public const int FiscalItem_IsNotCancelled = 164;
        public const int FiscalItem_IsNotRegistered = 165;


        public const int WorkSessionIsNull = 180;
        public const int WorkSessionIsClosed = 181;
        public const int WorkSessionIsNotClosed = 182;
        public const int WorkSessionCloserDateTimeBeforeItsOpening = 183;
        public const int WorkSessionOpenDateTimeBeforePreviousClose = 184;
        public const int WorkSessionOpenDateTimeBeforeDateOfRegistration = 185;
        public const int WorkSessionMove_WorkSessionOpenDateTimeBeforePreviousClose = 186;
        public const int WorkSessionMove_WorkSessionTimeHasBeenExceeded = 187;
        public const int WorkSession_HasNotAccepted = 188;
        public const int No_WorkSessions_Registered = 189;

        public const int WorkSessionMissedDocumentNumbersDetectionFailed = 190;


        public const int WrongPeriodDescription = 200;

        public const int XmlException = 220;
        public const int XmlDoesNotHaveDeclaration = 221;
        public const int SigningDateTimeNotFound = 222;
        public const int SigningCertificateNotFound = 223;
        public const int XmlSignatureValidationFailed = 224;
        public const int OperationNameNotFound = 225;
        public const int OperationNameNotRegistered = 226;
        public const int XmlDesearializationError = 227;
        public const int WrongOperation = 228;

        public const int DocumentNumberIsNull = 229;
        public const int NotRegisteredDocumentNumber = 230;
        public const int UseAnotherMethodForOperationReversing = 231;

        public const int CashierCertificateNotFound = 232;
        public const int CashierCertificateDisabled = 233;
        public const int CashierCertificateDoesNotMatch = 234;

        // Reports saving validation.
        public const int ReportDataIsNull = 240;
        public const int ReportKKMIsNull = 241;
        public const int ReportCurrencyIsNull = 242;
        public const int ReportNumberNotUniqueNull = 243;
        public const int ReportCantDelete = 244;

        // Z-report saving validation.
        public const int ZReportWorkSessionIsNull = 250;
        public const int ZReportCurrencyNotUniqueNull = 251;

        // KKM and KKMRegistrationCard saving validation.
        public const int KKMRegistrationCardOwnerIsNull = 260;
        public const int KKMSerialNumberIsNull = 261;
        public const int KKMNameIsNull = 262;
        public const int KKMRegistrationCardTaxationIsNull = 263;
        public const int KKMRegistrationCardAddressIsNull = 264;
        public const int KKMModeOfOperationIsNull = 265;
        public const int KKMSerialNumberTooLong = 266;
        public const int KKMNameTooLong = 267;
        public const int KKMClientSystemGuidTooLong = 268;
        public const int KKMRegistrationCardAddressTooLong = 269;
        public const int KKMModeOfOperationTooLong = 270;
        public const int KKMRegistrationCardRNMTooLong = 271;
        public const int KKMRegistrationCardOwnerNotSaved = 272;
        public const int KKMRegistrationCardRKONotSaved = 273;
        public const int KKMRegistrationCardTaxationNotSaved = 274;
        public const int KKMSerialNumberNotUnique = 275;
        public const int KKMClientSystemGuidNotUnique = 276;
        public const int KKMRegistrationCardRegistrationDateIsNull = 277;
        public const int KKMRegistrationCardRNMNotUnique = 278;
        public const int KKMRegistrationCardRNMIsNUll = 279;
        public const int KKMRegistrationCardFilledUserIsNull = 280;
        public const int KKMRegistrationCardUpdateUserIsNull = 281;
        public const int KKMRegistrationCardFilledUserNotSaved = 282;
        public const int KKMRegistrationCardFillDateIsNull = 283;
        public const int KKMRegistrationCardUpdateUserNotSaved = 284;
        public const int KKMRegistrationCardUpdateDateIsNull = 285;
        public const int KKMRegistrationDataIsNull = 286;
        public const int KKMRegistrationCardWorkSessionIsOpen = 287;
        public const int KKMRegistrationCardHasOperations = 288;
        public const int KKMRegistrationCardHasFiscalReports = 289;
        public const int KKMRegistrationCardDeregistrationDateLessThanLastWorkSession = 290;
        public const int KKMRegistrationCardDeregistrationDateLessThanRegistrationDate = 291;
        public const int KKMRegistrationDataAlreadyFilled = 292;
        public const int KKMChangesNotAllowedWithOpenWorkSession = 293;
        public const int KKMNotAvaliable = 294;
        public const int KKMDeregistrationWithoutFiscalReport = 295;
        public const int KKMClientSystemGuidIsEmpty = 296;
        public const int KKMRegistrationCardExist = 297;
        public const int KKMTypeIsNull = 268;
        public const int KKMTaxPayerIsNull = 269;
        public const int KKMDeregistrationWithNonZeroBalance = 298;
        public const int KKMRegistrationCardAnotherTaxation = 299;

        // KKM deletion validation.
        public const int KKMRegistrationCardHasLinkedRKO = 300;
        public const int KKMRegistrationCardHasLinkedFiscalInfo = 301;
        public const int KKMRegistrationCardHasLinkedEntries = 302;
        public const int KKMRegistrationCardHasLinkedWorkSessions = 303;
        public const int KKMRegistrationCardHasLinkedZReports = 304;
        public const int KKMRegistrationCardHasLinkedFiscalReports = 304;
        public const int KKMRegistrationCardHasLinkedCounters = 305;
        public const int KKMRegistrationCardCantBeDeletedIsClosed = 306;
        public const int KKMRegistrationCardCantBeDeletedIsRegistered = 309;
        public const int KKMHasReferences = 307;
        public const int KKMHasLinkedRegistrationCards = 308;

        public const int KKMRegistrationCardNotFound = 309;


        public const int TryToSaveDeletedEntry = 310;
        public const int TryToDeleteNotSavedEntry = 311;
        public const int TryToDeleteDeletedEntry = 312;


        // Work session saving/deleting.
        public const int WorkSessionCantBeDeleted = 320;
        public const int WorkSessionClosingDateIsNull = 321;
        public const int WorkSessionNumberNotUnique = 322;
        public const int WorkSessionKKMIsNull = 323;
        public const int WorkSessionClosingRequestDateIsNull = 324;

        // Access rules saving.
        public const int AccessRuleIntervalNotValid = 330;
        public const int AccessRuleTaxInspectorNotSaved = 331;


        // Cashier saving.
        public const int CashierNameIsNull = 340;
        public const int CashierClientSystemGuidIsNull = 341;
        public const int CashierNameTooLong = 342;
        public const int CashierClientSystemGuidTooLong = 343;
        public const int CashierClientSystemGuidNotUnique = 344;

        // Cashier deleting.
        public const int CashierHasLinkedFiscalInfo = 345;
        public const int CashierHasLinkedEntries = 346;

        public const int CashierLoginTooLong = 347;
        public const int CashierLoginNotUnique = 348;

        // Fiscal item deleting.
        public const int FiscalItemCantBeDeleted = 350;

        // Fiscal item saving.
        public const int FiscalItemKKMIsNull = 351;
        public const int FiscalItemWorkSessionIsNull = 352;
        public const int FiscalItemClientSystemGuidIsNull = 353;
        public const int FiscalItemFiscalizationSystemGuidIsNull = 354;
        public const int DocumentNumberTooLong = 355;
        public const int DocumentNumberWorkSessionTooLong = 356;
        public const int ClientSystemGuidTooLong = 357;
        public const int FiscalisationSystemGuidWrongFormat = 358;
        public const int TagTooLong = 359;
        public const int FiscalizationSystemGuidNotUnique = 360;
        public const int OperationNumberNotUniqueInWorkSession = 361;
        public const int FiscalInfoCashierIsNull = 362;

        // Entry saving
        public const int EntryFiscalInfoIsNull = 370;
        public const int EntryKKMIsNull = 371;
        public const int EntryWorkSessionIsNull = 372;
        public const int EntryCurrencyIsNull = 373;
        public const int EntryAttributesTooLong = 374;
        public const int EntryCashierIsNull = 375;

        // Entry deleting
        public const int EntryCantBeDeleted = 376;

        // RKO saving
        public const int RKONameIsNull = 380;
        public const int RKOAddressIsNull = 381;
        public const int RKOTaxPayerIsNull = 382;
        public const int RKOTaxationIsNull = 383;
        public const int RKOClientSystemGuidIsNull = 384;
        public const int RKONameTooLong = 385;
        public const int RKOAddressTooLong = 386;
        public const int RKOContactInformationTooLong = 386;
        public const int RKOClientSystemGuidTooLong = 387;
        public const int RKOTaxPayerNotSaved = 388;
        public const int RKOTaxationNotSaved = 389;
        public const int RKONameTaxPayerNotUnique = 390;
        public const int RKOClientSystemGuidNotUnique = 391;

        // RKO deleting
        public const int RKOHasLinkedKKM = 392;
        public const int RKOHasLinkedFiscalItems = 393;
        public const int RKOHasLinkedEntries = 394;

        // Certificate saving
        public const int CertificateIsNull = 401;
        public const int CertificateNotValid = 402;
        public const int CertificateNameIsNull = 403;
        public const int CertificateNameTooLong = 404;
        public const int CertificateVersionIsNull = 405;
        public const int CertificateVersionTooLong = 406;
        public const int CertificateSerialNumberIsNull = 407;
        public const int CertificateSerialNumberTooLong = 408;

        // Currency saving
        public const int CurrencyISOCodeIsNull = 410;
        public const int CurrencyISOCodeIsZero = 411;
        public const int CurrencyNameRusIsNull = 412;
        public const int CurrencyNameKazIsNull = 413;
        public const int CurrencyISOCodeTooLong = 414;
        public const int CurrencyNameRusTooLong = 415;
        public const int CurrencyNameKazTooLong = 416;
        public const int CurrencyISOCodeNotUnique = 417;
        public const int CurrencyDigitalISOCodeNotUnique = 418;
        public const int CurrencyNameRusNotUnique = 419;
        public const int CurrencyNameKazNotUnique = 420;

        // Currency deleting
        public const int CurrencyCantBeDeletedDefault = 421;
        public const int CurrencyHasLinkedDescription = 422;
        public const int CurrencyHasLinkedEntries = 423;

        // Tax payer saving
        public const int TaxPayerNameIsNull = 430;
        public const int TaxPayerINNIsNull = 431;
        public const int TaxPayerAddressIsNull = 432;
        public const int TaxPayerRNNHasWrongFormat = 433;
        public const int TaxPayerINNHasWrongFormat = 434;
        public const int TaxPayerNameTooLong = 435;
        public const int TaxPayerRNNTooLong = 436;
        public const int TaxPayerINNTooLong = 437;
        public const int TaxPayerAddressTooLong = 438;
        public const int TaxPayerContactInfoTooLong = 439;
        public const int TaxPayerNameNotUnique = 440;
        public const int TaxPayerRNNNotUnique = 441;
        public const int TaxPayerINNNotUnique = 442;

        // Tax payer deleting
        public const int TaxPayerHasLinkedRKO = 443;
        public const int TaxPayerHasLinkedKKM = 444;
        public const int TaxPayerHasLinkedCashier = 445;
        public const int TaxPayerHasLinkedCertificate = 446;
        public const int TaxPayerHasLinkedAdministrator = 447;
        public const int TaxPayerHasLinkedTaxationGroup = 448;
        public const int TaxPayerHasLinkedItemCategory = 449;

        // Taxation saving
        public const int TaxationNameRusIsNull = 450;
        public const int TaxationNameKazIsNull = 451;
        public const int TaxationAddressIsNull = 452;
        public const int TaxationNameRusTooLong = 453;
        public const int TaxationNameKazTooLong = 454;
        public const int TaxationAddressTooLong = 455;
        public const int TaxationContactInfoTooLong = 456;
        public const int TaxationNameRusNotUnique = 457;
        public const int TaxationNameKazNotUnique = 458;

        // Taxation deleting
        public const int TaxationHasLinkedTaxInspectors = 459;
        public const int TaxationHasLinkedRKO = 460;
        public const int TaxationHasLinkedKKM = 461;

        // User saving
        public const int UserNameIsNull = 470;
        public const int UserLoginIsNull = 471;
        public const int UserPasswordIsNull = 472;
        public const int UserLanguageIsNull = 473;
        public const int UserRegistrationDateIsNull = 474;
        public const int UserNameTooLong = 475;
        public const int UserContactInfoTooLong = 476;
        public const int UserLoginTooLong = 477;
        public const int UserLanguageIsWrong = 478;
        public const int UserFirstLoginDateIsNull = 479;
        public const int UserLastLoginDateIsNull = 480;

        // Tax inspector saving
        public const int TaxInspectorTaxationIsNull = 481;
        public const int UserLoginNotUnique = 482;
        public const int TaxInspectorTaxationNotSaved = 483;

        // Tax inspector deleting
        public const int TaxInspectorHasLinkedRegistrationCards = 484;
        public const int TaxInspectorHasLinkedFiscalReports = 485;
        public const int TaxInspectorHasLinkedAccessRules = 486;
        public const int TaxInspectorHasLinkedCertificate = 487;

        // Tax inspector facade saving
        public const int TaxInspectorFacadePassworkTooSmall = 488;

        // Administrator saving
        public const int CantDeactivateLastActiveRecord = 490;

        // Administrator deleting
        public const int CantDeleteLastActiveRecord = 491;
        public const int AdministratorHasLinkedRegistrationCards = 492;
        public const int AdministratorHasLinkedEntries = 493;

        // Cash desk saving
        public const int CashDeskNameIsNull = 500;
        public const int CashDeskKKMRegistrationCardIsNull = 501;
        public const int CashDeskClientSystemGuidIsNull = 502;
        public const int CashDeskNameTooLong = 503;
        public const int CashDeskClientSystemGuidTooLong = 504;
        public const int CashDeskKKMRegistrationCardNotSaved = 505;
        public const int CashDeskClientSystemGuidNotUnique = 506;

        // Cash desk deleting
        public const int CashDeskHasLinkedFiscalItems = 507;
        public const int CashDeskHasLinkedEntries = 508;

        // User facade saving
        public const int PasswordMustContainLetter = 510;
        public const int PasswordMustContainDigit = 511;
        public const int PasswordMustContainSymbols = 512;
        public const int PasswordContainSpaces = 513;
        public const int PasswordTooLong = 514;
        public const int PasswordsAreNotEquals = 515;
        public const int PasswordEqualsCurrent = 516;

        // Consolidated fiscal report saving
        public const int ConsolidatedFiscalReportDataIsNull = 520;
        public const int ConsolidatedFiscalReportTaxationIsNull = 521;
        public const int ConsolidatedFiscalReportCurrencyIsNull = 522;
        public const int ConsolidatedFiscalReportNumberNotUnique = 523;

        // Fiscal report log entry deleting
        public const int FiscalReportRecordsCantBeDeleted = 530;

        // Document number counter saving
        public const int DocumentNumberCounterInitialWrongValue = 540;
        public const int DocumentNumberCounterNewWrongValue = 541;
        public const int DocumentNumberCounterUserNotFound = 542;
        public const int DocumentNumberCounterChangeReasonIsNull = 543;

        // Counter with tax payer saving
        public const int CounterTaxPayerIsNull = 550;
        public const int CounterHasManyTaxPayers = 551;
        public const int CounterHasManyKKM = 552;
        public const int KKMHasManyCounters = 553;

        // Authenticate 
        public const int UserHaveNoPermitionsForApplication = 560;
        public const int UserHaveNoEnabledCertificate = 561;

        // Other
        public const int TestModeAlreadyActivated = 570;
        public const int TestModeCantActivateKKMIsRegisteredInTaxation = 571;
        public const int CantEditTaxationRegistrationDataTestModeNotActivated = 572;
        public const int TestModeDisactivated = 573;
        public const int KKMIsNotSpecified = 574;
        public const int OperationIsEmpty = 575;
        public const int KKMNotFound = 576;
        public const int TestModeCantActivateKKMRegisteredInTaxationCards = 577;

        public const int WorkSessionNotRegistered = 577;
        public const int CurrencyNotRegistered = 578;
        public const int CashierNotRegistered = 579;
        public const int RKONotRegistered = 580;
        public const int CantGetDocumentCounterValueWithOpenWorkSession = 581;
        public const int CantContainOperationWithSuchDocumentNumber = 582;

        public const int WrongDecimalAmountFormat = 590;
        public const int CurrencyDigitalISOCodeTooLong = 591;
        public const int CurrencyISOCodeWrongFormat = 592;
        public const int RNN_BINWrongFormat = 593;
        public const int WrongKKMModeOfOperation = 594;
        public const int WrongBooleanValue = 595;

        public const int CurrencyDoesNotBelongsToKKM = 596;
        public const int CashierDoesNotBelongsToKKM = 597;

        public const int WrongKKMType = 598;


        // License
        public const int LicenseFileIsNull = 600;

        // Work session closing requests.
        public const int WorkSessionClosingRequestNotExecuted = 610;
        public const int WorkSessionClosingRequestStatusEmpty = 611;

        // Active directory domain
        public const int ActiveDirectoryDomainNameEmpty = 620;
        public const int ActiveDirectoryDomainConnectionStringEmpty = 621;
        public const int ActiveDirectoryDomainLoginEmpty = 622;
        public const int ActiveDirectoryDomainPasswordEmpty = 623;
        public const int ActiveDirectoryDomainNameTooLong = 624;
        public const int ActiveDirectoryDomainConnectionStringTooLong = 625;
        public const int ActiveDirectoryDomainLoginTooLong = 626;
        public const int ActiveDirectoryDomainPasswordTooLong = 627;
        public const int ActiveDirectoryDomainHasLinkedEntries = 628;
        public const int ActiveDirectoryDomainConnectionStringNotUnique = 629;
        public const int ActiveDirectoryDomainUserDomainIsNull = 630;
        public const int ActiveDirectoryDomainUserNotExist = 631;
        public const int ActiveDirectoryDomainUserInfoNotAvaliable = 632;
        public const int ActiveDirectoryDomainNameNotUnique = 633;
        public const int ActiveDirectoryDomainUserDisabled = 634;

        public const int ZReportCanNotBeRetrieved = 640;
        public const int XReportCanNotBeRetrieved = 641;


        public const int KKMRegistrationCardAccumulationCardIsEmpty = 650;
        public const int KKMRegistrationCardAccumulationCardNotSaved = 651;
        public const int KKMRegistrationCardAccumulationCurrencyIsEmpty = 652;
        public const int KKMRegistrationCardAccumulationCurrencyNotSaved = 653;

        public const int KKMRegistrationCardDateOfRegistrationInvalid = 660;
        public const int KKMRegistrationCardDeregistrationReasonIsNull = 661;
        public const int KKMRegistrationCardDeregistrationReasonCanNotBeIncorrectData = 662;

        // DeregistrationReason saving
        public const int DeregistrationReasonCodeIsNull = 670;
        public const int DeregistrationReasonNameRusIsNull = 671;
        public const int DeregistrationReasonNameKazIsNull = 672;
        public const int DeregistrationReasonCodeTooLong = 673;
        public const int DeregistrationReasonNameRusTooLong = 674;
        public const int DeregistrationReasonNameKazTooLong = 675;
        public const int DeregistrationReasonCodeNotUnique = 676;
        public const int DeregistrationReasonCantBeDeletedDefault = 677;
        public const int DeregistrationReasonHasLinkedRegistrationCard = 678;

        public const int CertificateSignatureAlgorithmIsNull = 680;
        public const int CertificateSignatureAlgorithmTooLong = 681;
        public const int CertificateIssuerIsNull = 682;
        public const int CertificateIssuerTooLong = 683;
        public const int CertificateValidFromIsNull = 684;
        public const int CertificateValidToIsNull = 685;
        public const int CertificateSubjectIsNull = 686;
        public const int CertificateSubjectTooLong = 687;
        public const int CertificateThumbprintIsNull = 688;
        public const int CertificateThumbprintTooLong = 689;
        public const int CertificateGroupNotSaved = 690;
        public const int CertificateKeyUsageIsNull = 691;
        public const int CertificateKeyUsageTooLong = 692;
        public const int CertificateNameNoUniqueWithNoTaxPayer = 693;
        public const int CertificateNameNoUniqueWithTaxPayer = 694;
        public const int CertificateCanNotAtach = 695;
        public const int CertificateCanNotDetach = 696;
        public const int CashierHasLinkedCertificate = 697;

        public const int DocumentNumberMonitoringCanNotGenerateReport = 700;
        public const int DocumentNumberMonitoringMaxMissedCount = 701;

        public const int CertificateGroupNotEmpty = 705;
        public const int CertificateGroupNameIsNull = 706;
        public const int CertificateGroupNameTooLong = 707;
        public const int CertificateGroupDescriptionTooLong = 708;
        public const int CertificateGroupNameIsNotUnique = 709;

        public const int CertificateNotSaved = 710;
        public const int TaxPayerNotSaved = 711;
        public const int CantAttachTaxPayer = 712;
        public const int CashierTaxPayerNotSaved = 713;
        public const int NativeAdministratorTaxPayerNotSaved = 714;
        public const int DomainAdministratorTaxPayerNotSaved = 715;

        public const int TaxPayerNotFound = 716;

        public const int TaxationGroupNameIsNull = 720;
        public const int TaxationGroupNameTooLong = 721;
        public const int TaxationGroupCodeIsNull = 722;
        public const int TaxationGroupCodeTooLong = 723;
        public const int TaxationGroupCodeIsInvalid = 724;
        public const int TaxationGroupVATIsInvalid = 725;
        public const int TaxationGroupSalesTaxIsInvalid = 726;
        public const int TaxationGroupTaxPayerIsNull = 727;
        public const int TaxationGroupTaxPayerNotSaved = 728;
        public const int TaxationGroupCodeNotUnique = 729;
        public const int TaxationGroupNameNotUnique = 730;

        public const int DomainAdministratorLoginNotUnique = 731;

        public const int TaxationGroupNotFound = 732;

        public const int ItemCategoryNameIsNull = 740;
        public const int ItemCategoryNameTooLong = 741;
        public const int ItemCategoryCodeIsNull = 742;
        public const int ItemCategoryCodeTooLong = 743;
        public const int ItemCategoryCodeIsInvalid = 744;
        public const int ItemCategoryTaxPayerIsNull = 745;
        public const int ItemCategoryTaxPayerNotSaved = 746;
        public const int ItemCategoryCodeNotUnique = 747;
        public const int ItemCategoryNameNotUnique = 748;
        public const int ItemCategoryTaxationGroupIsNull = 749;
        public const int ItemCategoryTaxationGroupNotSaved = 750;
        public const int TaxationGroupHasLinkedCategories = 751;
        public const int ItemCategoryCountLimitReached = 752;
        public const int TaxationGroupCountLimitReached = 753;

        public const int JsonException = 760;
        public const int JsonDesearializationError = 761;
        public const int JsonSignatureValidationFailed = 762;

        public const int CashierTaxPayerIsEmpty = 770;
        public const int CashierTaxPayerIsWrong = 771;
        public const int AdministratorTaxPayerIsEmpty = 772;
        public const int KKMCantInitializeTypeIsVirtual = 773;
        public const int KKMCantInitializeAlreadyInitialized = 774;
        public const int KKMCantInitializeNotRegistered = 775;
        public const int KKMCantInitializeDeviceIdIsUsed = 776;


        public const int KeyContainerPublicKeyUpdateDateTimeIsEmpty = 780;
        public const int KeyContainerPrivateKeyUpdateDateTimeIsEmpty = 781;
        public const int KeyContainerPublicKeyUpdatedUserIsEmpty = 782;
        public const int KeyContainerPrivateKeyUpdatedUserIsEmpty = 783;
        public const int KeyContainerPublicKeyUpdatedUserNotPersisted = 784;
        public const int KeyContainerPrivateKeyUpdatedUserNotPersisted = 785;

        public const int KeyContainerGroupTaxPayerNotPersisted = 790;

        public const int NotAuthorizedExceptionCode = 900;
        public const int InactiveSessionExceptionCode = 901;
        public const int ActiveSessionFisihedExceptionCode = 902;
        public const int WrongSessionGuidExceptionCode = 903;
        public const int EmptySessionGuidExceptionCode = 904;


        public const int DictionaryNameIsEmpty = 910;
        public const int DictionaryNameTooLong = 911;
        public const int DictionaryVersionTaxPayerIsEmpty = 912;
        public const int DictionaryVersionTaxPayerNotSaved = 913;
        public const int DictionaryDataIsEmpty = 914;
        public const int DictionaryVersionWrong = 915;
        public const int DictionaryVersionExist = 916;
        public const int DictionaryCreationDateTimeIsEmpty = 917;
        public const int DictionaryCreationDateTimeWrong = 918;

        // DocumentNumberMonitoringExecutionList saving
        public const int DocumentNumberMonitoringExecutionListStatusEmpty = 920;
        public const int DocumentNumberMonitoringExecutionListWorkSessionEmpty = 921;
        public const int DocumentNumberMonitoringExecutionListStatusWrong = 922;
        public const int DocumentNumberMonitoringExecutionListWorkSessionNotSaved = 923;

        public const int PageSizeMustBeGreaterThanZero = 924;
        public const int PageNumberMustBeGreaterThanZero = 925;


        public const int BadPatchCreated = 930;
        public const int SignatureNotFound = 940;

        public const int KKMHasNotRegistrationCard = 950;
        public const int KKMHasTestRegistrationCard = 951;
        public const int KKMRegistrationCardIsClosed = 952;
        public const int KKMHasNotTestRegistrationCard = 953;
        public const int KKMNoClosingRegistrationCardRequest = 954;

        public const int DeviceFirmwareRegistrationDateTimeIsEmpty = 960;
        public const int DeviceFirmwareDataIsEmpty = 961;
        public const int DeviceFirmwareVersionIsEmpty = 962;
        public const int DeviceFirmwareCriticalVerionMustBeOne = 963;
        public const int DeviceFirmwareCanNotDeleteCriticalVerion = 964;
        public const int DeviceFirmwareVerionNotUnique = 965;
        public const int ResourceNotFound = 966;
        public const int KKMDeviceFirmwareNotFound = 967;
        public const int DeviceFirmwareVersionIsOld = 968;
        public const int DeviceFirmwareListIsEmpty = 969;
        public const int KKMDeviceFirmwareCurrentVersionIsHigher = 970;


        public static string TransformToRequestResultCode(int code)
        {
            return (Convert.ToInt32(RequestResultCodes.VALIDATION_FAILED_CODE) + code).ToString();
        }
    }
}