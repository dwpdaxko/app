configs = 
{
  :specs =>
  {
    :runner_options => ["-x","example"],
    :assemblies => dynamic{Dir.glob("#{configatron.artifacts_dir}/*specs.dll")},
    :dir => delayed{File.join(configatron.artifacts_dir,"specs")},
    :report_dir => delayed{File.join(configatron.specs.dir,"report")},
    :tools_folder => File.join(Dir.glob("packages/Machine.Specifications.*").first,"tools")
  }
}
configatron.configure_from_hash configs


