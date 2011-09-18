configs = 
{
  :db => 
  {
    :server_name => ENV['HOSTNAME'],
    :osql_connection_string => delayed{"-E \-S #{configatron.db.server_name}"},
    :osql_exe => "osql",
    :database_provider => "System.Data.SqlClient",
    :osql_args_prior_to_file_name => "-b -i"
  }
}

configatron.configure_from_hash configs
