import { useLoader } from '@react-three/fiber';
import { TextureLoader } from 'three';
import woodTextureImg from '../assets/wood_floor.jpg';
import wallpaperImg from '../assets/wallpaper.jpg';

export default function FloorAndWalls() {
    const woodTexture = useLoader(TextureLoader, woodTextureImg);
    const wallpaperTexture = useLoader(TextureLoader, wallpaperImg);

    return (
        <>
            {/* Golvet */}
            <mesh rotation={[-Math.PI / 2, 0, 0]} position={[0, -1.25, 0]}>
                <planeGeometry args={[20, 20]} />
                <meshStandardMaterial map={woodTexture} />
            </mesh>

            {/* Bakre vägg */}
            <mesh rotation={[0, 0, 0]} position={[0, 2, -10]}>
                <planeGeometry args={[20, 10]} />
                <meshStandardMaterial map={wallpaperTexture} />
            </mesh>

            {/* Sidovägg vänster */}
            <mesh rotation={[0, Math.PI / 2, 0]} position={[-10, 2, 0]}>
                <planeGeometry args={[20, 10]} />
                <meshStandardMaterial map={wallpaperTexture} />
            </mesh>

            {/* Sidovägg höger */}
            <mesh rotation={[0, -Math.PI / 2, 0]} position={[10, 2, 0]}>
                <planeGeometry args={[20, 10]} />
                <meshStandardMaterial map={wallpaperTexture} />
            </mesh>
        </>
    );
}
