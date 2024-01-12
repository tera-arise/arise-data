#nullable enable

// Arguments

var target = Argument("t", "default");

// Paths

var sheets = Context.Environment.WorkingDirectory.Combine("sheets");

// Tasks

Task("default")
    .IsDependentOn("build");

Task("build-core")
    .Does(() =>
        DotNetTool(
            null,
            "novadrop-dc validate",
            new ProcessArgumentBuilder()
                .AppendQuoted(sheets.FullPath)));

Task("build")
    .IsDependentOn("build-core");

RunTarget(target);
