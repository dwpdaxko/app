. .\psh_git_utils.ps1

exit_if_on_the_master_branch

git add -A
git commit -m "Pushing new changes"
git push origin

