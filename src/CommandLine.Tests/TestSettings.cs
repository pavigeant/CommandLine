namespace CommandLine.Tests
{
    public class SingleVerbSetting
    {
        public bool Verb { get; set; }

        public bool Param1 { get; set; }

        public bool Param2 { get; set; }

        public bool Param3 { get; set; }
    }

    public class VerbWithSingleParameterSetting
    {
        public string New { get; set; }
    }

    public class VerbWithMultipleParametersSetting
    {
        public string[] Transfer { get; set; }
    }

    public class TwoVerbArgumentsSetting
    {
        public string New { get; set; }

        public bool Project { get; set; }
    }

    public class TwoVerbArgumentsArraySetting
    {
        public string[] New { get; set; }

        public bool Project { get; set; }
    }

    public class ArgumentsSetting
    {
        public string[] Arguments { get; set; }
    }

    public class ArgsSetting
    {
        public string[] Args { get; set; }
    }

    public class LinuxPathSetting
    {
        public string Output { get; set; }
    }
}