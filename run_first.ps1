. .\psh_git_utils.ps1

function install_utilities()
{
  gem install bundler
  bundle install
}

function configure_remote()
{
  git remote rm jp
  git remote add jp git://github.com/dwpdaxko/app.git
}

function create_first_branch()
{
  checkout("start_of_week")
}

install_utilities
configure_remote
create_first_branch
