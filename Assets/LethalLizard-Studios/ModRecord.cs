using System;

[System.Serializable]
public class ModRecord
{
    public DateTime lastModified = DateTime.Today;
    public string modAuthor = "";
    public uint versionNumber = 1;
}
