config = 
{
  :course_name => 'Daxko - September 2011',
  :project => "nothinbutdotnetstore",
  :target => "Debug",
  :source_dir => "source",
  :all_references => UniqueFiles.new(Dir.glob("packages/**/*.{dll,exe}")).all_files,
  :artifacts_dir => "artifacts",
  :config_dir => "source/config",
  :app_dir => delayed{"source/#{configatron.project}.web.ui"},
  :log_file_name => delayed{"#{configatron.project}_log.txt"},
  :log_level => "DEBUG"
}
configatron.configure_from_hash config
