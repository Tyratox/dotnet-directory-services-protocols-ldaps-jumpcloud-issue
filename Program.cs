using System.DirectoryServices.Protocols;

var useTls = true;
var useJumpcloud = true;

var port = useTls ? 636 : 389;

Console.WriteLine("setup connection");

LdapConnection connection;

if (useJumpcloud)
{
    // does not work with TLS enabled, crashes badly
    connection = new LdapConnection($"ldap.jumpcloud.com:{port}")
    {
        AuthType = AuthType.Basic
    };
}
else
{
    // works
    connection = new LdapConnection($"ipa.demo1.freeipa.org:{port}")
    {
        AuthType = AuthType.Basic
    };
}



Console.WriteLine("setup options");

connection.SessionOptions.VerifyServerCertificate = (_, _) => true;
connection.SessionOptions.ProtocolVersion = 3;

if (useTls)
{
    connection.SessionOptions.SecureSocketLayer = true;
}

Console.WriteLine("bind");

connection.Bind(/*credentials*/);

Console.WriteLine("yay");