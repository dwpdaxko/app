function exit_if_on_the_master_branch()
{
  $status = git status

  if ($status[0].endswith("master"))
  {
    "You need to run this on a non master branch"
    exit
  }
}

function checkout($branch_name)
{
  git checkout -b $branch_name
  git checkout $branch_name
}

function exit_if_not_on_the_master_branch()
{
  $status = git status

  if (! $status[0].endswith("master"))
  {
    "You need to run this on a master branch"
    exit
  }
}

