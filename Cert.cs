using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirefoxMissingCertMimeTypePatcher
{
    class Cert
    {
        public string ext;
        public string mimeType;

        public Cert(string ext, string mimeType)
        {
            this.ext = ext;
            this.mimeType = mimeType;
        }

        public bool getStatus()
        {
            if (!Tools.MimeTypesRdfExist())
            {
                return false;
            }

            return System.Text.RegularExpressions.Regex.IsMatch(
                Tools.GetMimeTypesRdfText(),
                "NC:fileExtensions=\"" + this.ext + "\""
            );
        }

        public bool addEntry()
        {
            if (this.getStatus())
            {
                return false;
            }
            string rdfText = Tools.GetMimeTypesRdfText();
            rdfText = rdfText.Replace("</RDF:RDF>", "  <RDF:Description RDF:about=\"urn:mimetype:" + this.mimeType + "\"\n"
+ "                   NC:fileExtensions=\"" + this.ext + "\"\n"
+ "                   NC:description=\"Certificate (." + this.ext + ")\"\n"
+ "                   NC:value=\"" + this.mimeType + "\"\n"
+ "                   NC:editable=\"true\">\n"
+ "    <NC:handlerProp RDF:resource=\"urn:mimetype:handler:" + this.mimeType + "\"/>\n"
+ "  </RDF:Description>\n"
+ "</RDF:RDF>");

            System.IO.File.WriteAllText(Tools.GetMimeTypesRdfPath(), rdfText);

            return true;
        }
    }
}
