import { useLoader } from '@react-three/fiber';
import { TextureLoader } from 'three';
import woodTextureImg from '../assets/wood_floor.jpg';
import wallpaperImg1 from '../assets/wallpaper.jpg';
import wallpaperImg2 from '../assets/wallpaper2.jpg';

export default function FloorAndWalls() {
    const woodTexture = useLoader(TextureLoader, woodTextureImg);
    const wallpaperTexture1 = useLoader(TextureLoader, wallpaperImg1);
    const wallpaperTexture2 = useLoader(TextureLoader, wallpaperImg2);

    return (
        <>
            {/* Golvet */}
            <mesh rotation={[-Math.PI / 2, 0, 0]} position={[0, -3, 0]}>
                <planeGeometry args={[20, 20]} />
                <meshStandardMaterial map={woodTexture} />
            </mesh>

            {/* Bakre vägg */}
            <mesh rotation={[0, 0, 0]} position={[0, 2, -10]}>
                <planeGeometry args={[20, 10]} />
                <meshStandardMaterial map={wallpaperTexture1} />
            </mesh>

            {/* Sidovägg vänster */}
            <mesh rotation={[0, Math.PI / 2, 0]} position={[-10, 2, 0]}>
                <planeGeometry args={[20, 10]} />
                <meshStandardMaterial map={wallpaperTexture2} />
            </mesh>

            {/* Sidovägg höger */}
            <mesh rotation={[0, -Math.PI / 2, 0]} position={[10, 2, 0]}>
                <planeGeometry args={[20, 10]} />
                <meshStandardMaterial map={wallpaperTexture2} />
            </mesh>
        </>
    );
}
