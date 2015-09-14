rsync -r web pstatic:
ssh pstatic -t "$( cat <<'EOT'
  cp -R web polish
  sudo chown -R www-data:www-data polish
  sudo rsync -A -r polish www-data/ld33/
  sudo rm -rf polish
EOT
)"
