using Xunit;

namespace CommandLine.Tests
{
    public class CommandLineTests
    {
        [Fact]
        public void ShouldParseSingleVerbAsBoolean()
        {
            var args = new[] { "verb", "-param1", "--param2", "/param3" };

            var settings = CommandLineReader.Parse<SingleVerbSetting>(args);

            Assert.True(settings.Verb);
            Assert.True(settings.Param1);
            Assert.True(settings.Param2);
            Assert.True(settings.Param3);
        }

        [Fact]
        public void ShouldParseVerbWithSingleParameter()
        {
            var args = new[] { "new", "project" };

            var settings = CommandLineReader.Parse<VerbWithSingleParameterSetting>(args);

            Assert.Equal("project", settings.New);
        }

        [Fact]
        public void ShouldParseVerbWithMultipleParameters()
        {
            var args = new[] { "transfer", "user1", "user2" };

            var settings = CommandLineReader.Parse<VerbWithMultipleParametersSetting>(args);

            Assert.Equal(new[] { "user1", "user2" }, settings.Transfer);
        }

        [Fact]
        public void ShouldThrowWhenMissingRequiredArgumentOnSingleVerb()
        {
            var args = new[] { "new" };

            Assert.Throws<CommandLineParserException>(() => CommandLineReader.Parse<VerbWithSingleParameterSetting>(args));
        }

        [Fact]
        public void ShouldThrowWhenMissingRequiredArgument()
        {
            var args = new[] { "new", "project" };

            Assert.Throws<CommandLineParserException>(() => CommandLineReader.Parse<TwoVerbArgumentsSetting>(args));
        }

        [Fact]
        public void ShouldThrowWhenMissingRequiredArgumentOnArray()
        {
            var args = new[] { "new", "project" };

            Assert.Throws<CommandLineParserException>(() => CommandLineReader.Parse<TwoVerbArgumentsArraySetting>(args));
        }

        [Fact]
        public void ShouldAssignArgumentsToArgumentsProperty()
        {
            var args = new[] { "arg1", "arg2" };

            var settings = CommandLineReader.Parse<ArgumentsSetting>(args);
            Assert.Equal(new[] { "arg1", "arg2" }, settings.Arguments);
        }

        [Fact]
        public void ShouldAssignArgsToArgsProperty()
        {
            var args = new[] { "arg1", "arg2" };

            var settings = CommandLineReader.Parse<ArgsSetting>(args);
            Assert.Equal(new[] { "arg1", "arg2" }, settings.Args);
        }

        [Fact]
        public void ShouldAcceptLinuxPath()
        {
            var args = new[] { "--output", "/var/test" };

            var settings = CommandLineReader.Parse<LinuxPathSetting>(args);
            Assert.Equal("/var/test", settings.Output);
        }

    }
}