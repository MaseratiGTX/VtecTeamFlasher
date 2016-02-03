FSCAppletHelper = {

    attributes: {},
    parameters: {},

    initialized: false,

    containerId: 'applet',
    name: 'FSCApplet',
    code: 'kz.neoservice.applet.FSCApplet.class',
    
    provider: '',
    language: '',

    javaMinimumVersion: '1.7',
    javaPath: 'Java/',

    
    Initialize: function () {
        this.InitializeDefaults();

        switch (this.provider) {
            case 'IolaCOM':
            case 'IolaJCE':
                this.InitializeWithIolaCryptoProvider();
            break;

            case 'VipNet':
            case 'VipNetJCE':
                this.InitializeWithVipNetCryptoProvider();
            break;

            case 'OpenSSL':
            case 'OpenSSLJCE':
                this.InitializeWithOpenSSLCryptoProvider();
            break;
        
            default:
                throw 'Error while applet initializing';
        }

        this.initialized = true;
    },
    

    InitializeWithIolaCryptoProvider: function() {
        this.attributes.type = 'application/x-java-applet';
        
        this.attributes.archive = this.javaPath + 'FSCJceProvider.jar, ' +
                                        this.javaPath + 'Iola/commons-logging-1.1.1.jar, ' +
                                        this.javaPath + 'Iola/softkey_jce_iola-2.1.jar, ' +
                                        this.javaPath + 'Iola/xmlsec-1.4.4.jar';

        this.parameters.providerType = 'IolaCOM';
    },
    
    InitializeWithVipNetCryptoProvider: function() {
        this.parameters.jnlp_href = this.javaPath + 'VipNet/JNLP/fscapplet.jnlp';

        this.parameters.providerType = 'VipNet';
    },
    
    InitializeWithOpenSSLCryptoProvider: function() {
        this.attributes.type = 'application/x-java-applet';

        this.attributes.archive = this.javaPath + 'FSCJceProvider.jar, ' +
                                        this.javaPath + 'OpenSSL/xmlsec-1.5.5.jar, ' +
                                        this.javaPath + 'OpenSSL/commons-logging-1.1.1.jar';

        this.parameters.providerType = 'OpenSSL';
    },
    

    Start: function (provider, language) {
        this.provider = provider;
        this.language = language;

        this.Initialize();

        if (this.initialized) {
            deployJava.runApplet(this.containerId, this.attributes, this.parameters, this.javaMinimumVersion);
        }
    },
    

    InitializeDefaults: function () {
        this.InitializeDefaultAttributes();
        this.InitializeDefaultParameters();
    },

    InitializeDefaultAttributes: function () {
        this.attributes.code = this.code;
        
        this.attributes.id = this.name;
        this.attributes.name = this.name;
        
        this.attributes.align = 'center';
        this.attributes.width = 10;
        this.attributes.height = 10;
    },

    InitializeDefaultParameters: function () {
        this.parameters.language = this.language;

        this.parameters.fontSize = 16;
        this.parameters.permissions = 'all-permissions';
        this.parameters.MAYSCRIPT = 'true';
        this.parameters.separate_jvm = 'true';
        this.parameters.codebase_lookup = false;
    },
    

    SelectKeyContainer: function() {
        document.applets[this.name].selectKeyContainer();
    },

    CheckPassword: function (password) {
        return document.applets[this.name].checkPassword(password);
    },

    SetPassword: function(password) {
        document.applets[this.name].setPassword(password);
    },

    InitProvider: function() {
        document.applets[this.name].initProvider();
    },

    SignXml: function(xml) {
        return document.applets[this.name].signXml(xml);
    }
}