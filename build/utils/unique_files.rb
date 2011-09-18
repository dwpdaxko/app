class UniqueFiles
  def initialize(all_files)
    @files = filter_unique(all_files)
  end

  def filter_unique(files)
    unique = {}
    files.each do|file|
      unique[File.basename(file)] = file
    end
    unique
  end

  def all_files
    items = []
    @files.each do|file_name,path|
      items.push(path)
    end
    items
  end
end
