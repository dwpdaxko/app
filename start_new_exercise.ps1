. .\psh_git_utils.ps1

exit_if_on_the_master_branch

$now = get-date
$new_branch_name = "$($now.year)$($now.month.tostring("00"))$($now.day.tostring("00"))$($now.hour.tostring("00"))$($now.minute.tostring("00"))$($now.second.tostring("00"))"
git add -A
git commit -m "Committing"

"Enter a meaningful branch name (leave empty if you don't need one)"
$branch_name = read-host
$branch_name = $branch_name.trim()

if ($branch_name -ne "")
{
  checkout($branch_name)
}

git checkout master

exit_if_not_on_the_master_branch

checkout($new_branch_name)
git pull jp master
echo "new branch name:$new_branch_name"

