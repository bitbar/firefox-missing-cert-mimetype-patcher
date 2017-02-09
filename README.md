# Firefox Missing Cert MIME Type Patcher
It's simple C# application which fixes missing MIME Types for certificates in Mozilla Firefox running on Windows.

### How it works
Mozilla Firefox @ Windows has from long time (among others [Bug 956189](https://bugzilla.mozilla.org/show_bug.cgi?id=956189)) problem with correct resolving MIME Types of certificates selected to upload. Fix for this is pretty simple - all you need to do is to add proper entries in **mimeTypes.rdf** file which is located in user Firefox Profile directory.

### How to use
1. Run **FirefoxMissingCertMimeTypePatcher.exe**  
![App window](https://raw.githubusercontent.com/bitbar/firefox-missing-cert-mimetype-patcher/master/doc/app-window.png)
2. Click **Fix missing**  
![App window](https://raw.githubusercontent.com/bitbar/firefox-missing-cert-mimetype-patcher/master/doc/app-done.png)
3. Restart Firefox (if it's currently running)

### How to rollback
If you want to rollback previous mimeTypes.rdf file, then remove it and rename mimeTypes.rdf.bak to mimeTypes.rdf .
Note: .bak file is overwrtitten after every click on "Fix missing"

### Supported MIME Types
- .pem (application/x-pem-file)
- .cer (application/pkix-cert)
- .crt (application/x-x509-user-cert)
- .der (application/x-x509-ca-cert)
- .p7b (application/x-pkcs7-certificates)
- .p7c (application/pkcs7-mime)
- .p12 (application/x-pkcs12)
- .pfx (application/x-pkcs12)

List created according to [OpenSSL MIME Types](http://pki-tutorial.readthedocs.io/en/latest/mime.html)
